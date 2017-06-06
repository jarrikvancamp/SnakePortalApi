using DTO;
using System.Threading.Tasks;

namespace BL.Abstract.Validation
{
    public interface IValidator<T> where T : DtoBase
    {
        Task<bool> Validate(T item);
    }
}
