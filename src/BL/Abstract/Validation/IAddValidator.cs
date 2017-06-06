using DTO;
using System.Threading.Tasks;

namespace BL.Abstract.Validation
{
    internal interface IAddValidator<T> where T : DtoBase
    {
		Task<bool> ValidateForAdd(T item);
		Task<bool> ValidateForWrite(T item);
    }
}
