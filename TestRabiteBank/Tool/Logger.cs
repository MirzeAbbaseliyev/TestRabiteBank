using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestRabiteBank.Entity;
using TestRabiteBank.Repository;
using TestRabiteBank.Repository.Interfaces;

namespace TestRabiteBank.Tool
{
    public static class Worker
    {
        static readonly object _object = new object();
        public static int CreateLog(Func<int,int,Task<int>> action,int a,int b ,string metodName)
        {
            lock (_object)
            {
                ICallRepository callRepository =new CallRepository();
                ICallDetalsRepository callDetalsRepository =new CallDetalsRepository();

                var result= callRepository.Insert(new Call { InsertDate = DateTime.Now });
                if (!result.Success)
                    return -1;
                callDetalsRepository.Insert(new CallDetals
                {
                    InsertDate = DateTime.Now
                    ,
                    ParentId = result.Value
                    ,
                    Value = metodName + ":  Request to JSON "+": a="+a+" b="+b
                });

                callDetalsRepository.Insert(new CallDetals
                {
                    InsertDate = DateTime.Now
                    ,
                    ParentId = result.Value
                    ,
                    Value = metodName + ":  Request to SOAP "
                });

                var r= action.Invoke(a,b);

                callDetalsRepository.Insert(new CallDetals
                {
                    InsertDate = DateTime.Now
                    ,
                    ParentId = result.Value
                    ,
                    Value = metodName + ":  Response from SOAP: " +r 
                });


                return r.Result;
            }
        }
    }
}
