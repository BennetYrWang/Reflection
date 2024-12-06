using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;

public class GameProgressManager
{
    private static readonly Dictionary<string, PropertyInfo> PropertyMap;

    static GameProgressManager()
    {
        // 初始化属性映射
        PropertyMap = new Dictionary<string, PropertyInfo>();
        foreach (var property in typeof(GameProgressManager).GetProperties(BindingFlags.Public | BindingFlags.Instance))
            PropertyMap[property.Name] = property;
    }
    
    public void SetProperty(string propertyName, string value)
    {
        // 尝试从缓存中获取属性信息
        if (!PropertyMap.TryGetValue(propertyName, out var property))
        {
            throw new ArgumentException($"Property '{propertyName}' not found.");
        }

        // 确保属性可写
        if (!property.CanWrite)
        {
            throw new InvalidOperationException($"Property '{propertyName}' is read-only.");
        }

        // 将值转换为属性的类型
        object convertedValue = ConvertToPropertyType(property.PropertyType, value);

        // 设置属性值
        property.SetValue(this, convertedValue);
    }

    // 将字符串转换为目标类型
    private object ConvertToPropertyType(Type targetType, string value)
    {
        if (targetType == typeof(string))
        {
            // 去掉前后的引号（如果有）
            return value.Trim('"');
        }
        else if (targetType == typeof(int))
        {
            return int.Parse(value);
        }
        else if (targetType == typeof(float))
        {
            return float.Parse(value, CultureInfo.InvariantCulture);
        }
        else if (targetType == typeof(bool))
        {
            return value.ToLower() == "true";
        }
        else
        {
            throw new NotSupportedException($"Type '{targetType.Name}' is not supported.");
        }
    }
}