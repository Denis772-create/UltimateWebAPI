using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Api.ModelBinders
{
    public class ArrayModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (!bindingContext.ModelMetadata.IsEnumerableType)   // получаем тип параметра метода, и если не generic то ошибка
            {
                bindingContext.Result = ModelBindingResult.Failed();
                return Task.CompletedTask;
            }

            var providedValue = bindingContext.ValueProvider  // достаем знаечение из параметров запроса
                .GetValue(bindingContext.ModelName).ToString();

            if (string.IsNullOrEmpty(providedValue))          // если пусто или null возвращаем успех и null
            {
                bindingContext.Result = ModelBindingResult.Success(null);
                return Task.CompletedTask;
            }

            var genericType = bindingContext.ModelType.GetTypeInfo().GenericTypeArguments[0];   // получаем тип дженерика котрый чежду <>, 0 -значит первый
            var converter = TypeDescriptor.GetConverter(genericType);                           // получаем конвертер в тип generic в нашем случае это Guid

            var objectArray = providedValue          // получаем массив object тип guid
                .Split(new[] {","}, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => converter.ConvertFromString(x.Trim()))
                .ToArray();

            var guidArray = Array.CreateInstance(genericType, objectArray.Length); // создаем массив типа genericType, и задаем его размерность согласно количеству параметров массива objectArray
            objectArray.CopyTo(guidArray, 0);   //копируем все в массив нужного нам типа
            bindingContext.Model = guidArray;   // помещаем это в модель параметра

            bindingContext.Result = ModelBindingResult.Success(bindingContext.Model); // передаем результат
            return Task.CompletedTask;
        }
    }
}
