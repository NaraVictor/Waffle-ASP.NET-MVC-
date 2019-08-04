using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Waffle.Data;
using Waffle.Repository;

namespace Waffle.ViewModels
    {
    public class ClassInfoVM
        {
        public ClassInfoVM(Class classInfo)
            {

            _class = classInfo;

            using (var db = WaffleContext.CreateDb())
                {

                var _topics = db.ClassTopic
                                .Where(t => t.ClassId == _class.ClassId)
                                .Include(t => t.Playlists)
                                .ToList();


                var _resources = db.ClassResource
                                .Where(r => r.ClassId == _class.ClassId)
                                .ToList();


                var _discussions = db.ClassDiscussion
                                .Where(d => d.ClassId == _class.ClassId)
                                .ToList();


                discussions = _discussions;
                resources = _resources;
                topics = _topics;

                }
            }


        public Class _class { get; set; }
        public IEnumerable<ClassTopic> topics { get; set; }
        public IEnumerable<ClassResources> resources { get; set; }
        public IEnumerable<ClassDiscussion> discussions { get; set; }

        }
    }