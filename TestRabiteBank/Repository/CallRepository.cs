using MicroORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestRabiteBank.Entity;
using TestRabiteBank.Repository.Interfaces;

namespace TestRabiteBank.Repository
{
    public class CallRepository:CRUD<Call>, ICallRepository
    {
    }
}
