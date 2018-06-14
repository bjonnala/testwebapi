using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testwebapi.Models;

namespace testwebapi.DAL
{
    public class Data : IData
    {
        TestContext _testContext;

        public Data(TestContext context)
        {
            _testContext = context;
        }
        public async Task<ResponseJSON> CreateUpdateAsync(RequestJSON createrequest)
        {
            ResponseJSON response = new ResponseJSON();
            try
            {
                
                    // Get record and update
                var guid = _testContext.Guid.Find(createrequest.guid);
                if (guid != null)
                {
                    if (!string.IsNullOrWhiteSpace(createrequest.expire))
                    {
                        guid.Expires = createrequest.expire;
                        await _testContext.SaveChangesAsync();
                    }
                    // Query the record back
                    var list = await _testContext.Guid
                                      .Where(p => p.UniqueId == createrequest.guid)
                                      .ToListAsync();

                    foreach (var item in list)
                    {
                        response.expire = item.Expires;
                        response.guid = item.UniqueId;
                        response.user = item.User;
                    }
                }
                else
                {
                    Models.Guid newguid = new Models.Guid
                    {
                        Expires = createrequest.expire,
                        UniqueId = createrequest.guid,
                        User = createrequest.user
                    };
                    _testContext.Add(newguid);
                    await _testContext.SaveChangesAsync();
                    var guids = await _testContext.Guid
                                      .Where(p => p.UniqueId == createrequest.guid)
                                      .ToListAsync();

                    foreach (var item in guids)
                    {
                        response.expire = item.Expires;
                        response.guid = item.UniqueId;
                        response.user = item.User;
                    }
                }   
                               
            }
            catch (Exception ex)
            {
                response.status = ex.Message;
            }
            return response;
        }

        public async Task DeleteAsync(string id)
        {
            var uniqueid = await _testContext.Guid.FindAsync(id);
            _testContext.Guid.Remove(uniqueid);
            await _testContext.SaveChangesAsync();
        }

        public async Task<ResponseJSON> ReadAsync(string id)
        {
            ResponseJSON response = new ResponseJSON();
            try
            {
                if (!string.IsNullOrWhiteSpace(id))
                {
                    var guids = await _testContext.Guid
                     .Where(p => p.UniqueId == id)
                     .ToListAsync();

                    foreach (var item in guids)
                    {
                        response.expire = item.Expires;
                        response.guid = item.UniqueId;
                        response.user = item.User;
                    }
                }
            }
            catch (Exception ex)
            {
                response.status = ex.Message;
            }
            return response;
        }

        /*public async Task<ResponseJSON> UpdateAsync(RequestJSON updaterequest)
        {
            ResponseJSON response = new ResponseJSON();
            try
            {
                // Get record and update
                var test = _testContext.Guid.Find(updaterequest.guid);
                test.Expires = updaterequest.expire;
                await _testContext.SaveChangesAsync();

                // Query the record back
                var guids = await _testContext.Guid
                                  .Where(p => p.UniqueId == updaterequest.guid)
                                  .ToListAsync();
                
                foreach (var item in guids)
                {
                    response.expire = item.Expires;
                    response.guid = item.UniqueId;
                    response.user = item.User;
                }
            }
            catch (Exception ex)
            {
                response.status = ex.Message;
            }

            return response;
        }*/
    }
}
