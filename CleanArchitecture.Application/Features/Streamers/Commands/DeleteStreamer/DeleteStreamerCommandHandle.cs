

using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.Streamers.Commands.DeleteStreamer
{
    public class DeleteStreamerCommandHandle : IRequestHandler<DeleteStreamerCommand>
    {
        private readonly IStreamerRepository _streamerRepository;
        private readonly IMapper mapper;
        private readonly ILogger<DeleteStreamerCommandHandle> _logger;

        public DeleteStreamerCommandHandle(IStreamerRepository streamerRepository, IMapper mapper, ILogger<DeleteStreamerCommandHandle> logger)
        {
            _streamerRepository = streamerRepository;
            this.mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteStreamerCommand request, CancellationToken cancellationToken)
        {
            Streamer streamertoDelete = await _streamerRepository.GetByIdAsync(request.Id);
            if (streamertoDelete == null)
            {
                _logger.LogError($"{request.Id} streamer no existe en el sistema");
                throw new NotFoundException(nameof(Streamer), request.Id);
            }

            await _streamerRepository.DeleteAsync(streamertoDelete.Id);

            _logger.LogInformation($"El {request.Id} streamer fue eliminado con exito");

            return Unit.Value;
        }
    }
}
