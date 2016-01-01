using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Messages
{
    internal class ModifyStudentMessage
    {
        public int StudentId;

        public ModifyStudentMessage(int studentId)
        {
            this.StudentId = studentId;
        }
    }
}