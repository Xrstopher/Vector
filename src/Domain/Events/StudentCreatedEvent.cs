﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vector.Domain.Common;
using Vector.Domain.Entities;

namespace Vector.Domain.Events
{
    public class StudentCreatedEvent : DomainEvent
    {
        public StudentCreatedEvent(Student student)
        {
            Student = student;
        }

        public Student Student { get; }
    }
}
