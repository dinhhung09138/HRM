using DotNetCore.Objects;

namespace HRM.Model
{
    public class BaseGridParameterModel : GridParameters
    {
        public string TextSearch { get; set; }

        public BaseGridParameterModel()
        {
            TextSearch = string.Empty;
            Page = new Page()
            {
                Index = 1,
                Size = 10,
            };
        }
    }
}
