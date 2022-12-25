using Kaizen.JsonParser.Model;

namespace Kaizen.JsonParser.Services
{
    public interface IStringBuilderService
    {
        string CreateStringBuilderForJsonModel(List<JsonModel> jsonModelFromSerializer);
    }

    public class StringBuilderService : IStringBuilderService
    {
        public string CreateStringBuilderForJsonModel(List<JsonModel> jsonModelFromSerializer)
        {
            var stringBuilder = new StringBuilder();
            var lineNumber = 1;

            var tempXValue = 0;
            var tempLineNumber = 0;

            for (int i = 1; i < jsonModelFromSerializer.Count; i++)
            {
                var item = jsonModelFromSerializer[i];
                var topLeftCorner = item.BoundingPoly.Vertices.Select(x => x.X).FirstOrDefault();
                if (tempXValue < topLeftCorner)
                {
                    if (lineNumber > tempLineNumber)
                        stringBuilder.Append($"{lineNumber}|");

                    stringBuilder.Append($"{item.Description} ");
                }
                else if (tempXValue >= topLeftCorner)
                {
                    lineNumber++;
                    stringBuilder.Append($"\n{lineNumber}|{item.Description} ");
                }
                else
                {
                    stringBuilder.Append($"\n{lineNumber}|{item.Description} \n");
                    lineNumber++;
                }

                tempXValue = topLeftCorner;
                tempLineNumber = lineNumber;
            }

            return stringBuilder.ToString();
        }
    }
}