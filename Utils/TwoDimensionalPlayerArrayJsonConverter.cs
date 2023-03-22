using System.Text.Json;
using System.Text.Json.Serialization;
using TestAssignmentSenseCapitalModels.Models;

namespace Utils;

public class TwoDimensionalPlayerArrayJsonConverter : JsonConverter<PlayerMark[,]>
{
	public override PlayerMark[,] Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		return null;
	}

	public override void Write(Utf8JsonWriter writer, PlayerMark[,] value, JsonSerializerOptions options)
	{
		writer.WriteStartArray();
		for (var i = 0; i < value.GetLength(0); i++)
		{
			writer.WriteStartArray();
			for (var j = 0; j < value.GetLength(1); j++)
			{
				writer.WriteStringValue(value[i, j].ToString());
			}
			writer.WriteEndArray();
		}
		writer.WriteEndArray();	}
}