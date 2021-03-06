﻿using System;
using Newtonsoft.Json;

namespace Magento.RestApi.Json
{
    public class Base64Converter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
        {
            if (value != null)
            {
                writer.WriteValue(Convert.ToBase64String((byte[]) value));
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            var value = reader.Value == null ? string.Empty : reader.Value.ToString();
            if (string.IsNullOrEmpty(value)) return null;
            return Convert.FromBase64String(value);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(byte[]);
        }
    }
}
