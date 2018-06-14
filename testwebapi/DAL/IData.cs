using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testwebapi.Models;

namespace testwebapi.DAL
{
    public interface IData
    {
        Task<ResponseJSON> CreateUpdateAsync(RequestJSON createrequest);
        Task<ResponseJSON> ReadAsync(string id);
        //Task<ResponseJSON> UpdateAsync(RequestJSON updaterequest);
        Task DeleteAsync(string id);

    }
}
