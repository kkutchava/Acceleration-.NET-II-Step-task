using System;
using Microsoft.EntityFrameworkCore;
using task7.Models;
using task7.Data;
using System.Collections.Generic;
using System.Linq;

using TeacherPupilContext cntx = new TeacherPupilContext();

// ***NOTE*** the insertion should happen once,
// since if it happens multiple times, we will
// have dublicate entries in DB

//inserting pupils
Pupil pup1 = new Pupil()
{
    nm = "Giorgi",
    surnm = "Wayne",
    gender = 'M',
    Class = "10th"
};
cntx.Pupil.Add(pup1);

Pupil pup2 = new Pupil()
{
    nm = "Jason",
    surnm = "Todd",
    gender = 'M',
    Class = "7th"
};
cntx.Pupil.Add(pup2);

//inserting Teachers
Teacher t1 = new Teacher()
{
    nm = "Sara",
    surnm = "Makkito",
    gender = 'F',
    subjct = "Math"
};
cntx.Teacher.Add(t1);

Teacher t2 = new Teacher()
{
    nm = "Caleb",
    surnm = "Makkito",
    gender = 'M',
    subjct = "Physics"
};
cntx.Teacher.Add(t2);

cntx.SaveChanges(); // Saveing changes to generate IDs fro pupil and teacher

//making relation
TP rel1 = new TP()
{
    TId = t1.TId,
    PId = pup1.PId
};
cntx.Tp.Add(rel1);

TP rel2 = new TP()
{
    TId = t2.TId,
    PId = pup1.PId
};
cntx.Tp.Add(rel2);

TP rel3 = new TP()
{
    TId = t2.TId,
    PId = pup2.PId
};
cntx.Tp.Add(rel3);

cntx.SaveChanges();



//TASK #7 creating function to query DB

static Teacher[] GetAllTeachersByStudent(string studentName)
{
    using TeacherPupilContext cntx = new TeacherPupilContext();
    var query = from teacher in cntx.Teacher
                join tp in cntx.Tp on teacher.TId equals tp.TId
                join pupil in cntx.Pupil on tp.PId equals pupil.PId
                where pupil.nm == studentName
                group teacher by new { teacher.TId, teacher.nm, teacher.surnm, teacher.subjct } into grouped
                select grouped.First();

    Teacher[] arr = query.Distinct().ToArray();

    return arr;
}

//checking

Teacher[] arr = GetAllTeachersByStudent("Giorgi");

for (int i = 0; i < arr.Length; i++)
{
    Console.WriteLine($"Giorgi's teacher in {arr[i].subjct} is {arr[i].nm} {arr[i].surnm}");
}