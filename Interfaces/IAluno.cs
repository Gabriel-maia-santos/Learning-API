using APIBoletim.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBoletim.Interfaces {
    interface IAluno {

        //Lerning DDD Interface
        Aluno Register(Aluno a);
        List<Aluno> ReadAll();
        Aluno SearchbyId(int id);
        Aluno Update(int id, Aluno a);
        void Delete(int id);
    }
}
