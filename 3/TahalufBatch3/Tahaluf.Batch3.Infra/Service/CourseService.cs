using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tahaluf.Batch3.Core.Data;
using Tahaluf.Batch3.Core.Services;

namespace Tahaluf.Batch3.Infra.Service
{
    public class CourseService : ICourseSevice
    {
        private static List<Courses> ListCoures = new List<Courses> {
            new Courses()
            {
                Id = 1,
                Date = DateTime.Now,
                Category = "Math",
                Name = "Math Course"
            },
            new Courses()
            {
                Id = 2,
                Date = DateTime.Now,
                Category = "IT",
                Name = "ASP.net"
            },
            new Courses()
            {
                Id = 3,
                Date = DateTime.Now,
                Category = "IT",
                Name = "Angular"
            },
            new Courses()
            {
                Id = 4,
                Date = DateTime.Now,
                Category = "IT",
                Name = "React"
            },
        };

        public List<Courses> GetAll()
        {
            return ListCoures;
        }

        public bool AddCourse(Courses model)
        {
            if (model.Id == 0)
            {
                if (model.Name == "" || model.Name == null ||
                    model.Category == "" || model.Category == null
                    )
                {
                    return false;
                }
                else
                {
                    model.Date = DateTime.Now;
                    model.Id = ListCoures.Max(a => a.Id) + 1;
                    ListCoures.Add(model);
                    return true;
                }
            }
            else
            {
                var Course = ListCoures.FirstOrDefault(a => a.Id == model.Id);

                if (Course == null) { return false; }

                Course.Name = model.Name;
                Course.Category = model.Category;
                Course.Date = DateTime.Now;

                return true;
            }
        }



        public bool DeleteCourse(int id)
        {
            var Course = ListCoures.FirstOrDefault(a => a.Id == id);

            if (Course == null) { return false; }

            ListCoures.Remove(Course);

            return true;
        }


    }


    public class MyClassService : IMyClass
    {
        private static List<MyClass> MyList = new List<MyClass>()
        {
            new MyClass()
            {
                Name = "AAA"
            },
            new MyClass()
            {
                Name = "A"
            },
            new MyClass()
            {
                Name = "AA"
            }
        };

        public List<MyClass> GetAll()
        {
            return MyList;
        }

        public List<MyClass> SearchByName(string Name)
        {
            return MyList.Where(a => a.Name.Contains(Name)).ToList();
        }

        public MyClass SearchByOneName(string Name)
        {
            return MyList.FirstOrDefault(a => a.Name == Name);
        }
    }
}
