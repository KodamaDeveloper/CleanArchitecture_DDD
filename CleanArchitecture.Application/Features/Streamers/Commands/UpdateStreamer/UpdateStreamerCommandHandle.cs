using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.Streamers.Commands.UpdateStreamer
{
    public class UpdateStreamerCommandHandle : IRequestHandler<UpdateStreamerCommand>
    {

        private readonly IStreamerRepository _streamerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateStreamerCommandHandle> _logger;

        public UpdateStreamerCommandHandle(IStreamerRepository streamerRepository, IMapper mapper, ILogger<UpdateStreamerCommandHandle> logger)
        {
            _streamerRepository = streamerRepository;
            this._mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateStreamerCommand request, CancellationToken cancellationToken)
        {
            Streamer streamertoUpdate = await _streamerRepository.GetByIdAsync(request.Id);
            if (streamertoUpdate == null)
            {
                _logger.LogError($"No se encontro el streamer id {request.Id}");
                throw new NotFoundException(nameof(Streamer), request.Id);
            }

            _mapper.Map(request, streamertoUpdate, typeof(UpdateStreamerCommand), typeof(Streamer));


            await _streamerRepository.UpdateAsync(streamertoUpdate);

            _logger.LogInformation($"La operacion fue exitosa actualizando el streamer {request.Id}");
            return Unit.Value;
        }
    }
}
