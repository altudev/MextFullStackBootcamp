using MextFullstackSaaS.Application.Common.Models.OpenAI;

namespace MextFullstackSaaS.Application.Common.Interfaces;

public interface IOpenAIService
{
    Task<List<string>> DallECreateIconAsync(DallECreateIconRequestDto requestDto,CancellationToken cancellationToken);
}