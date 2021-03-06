﻿using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Linq;
using Api;
using BraudeTimetabler.Models;

namespace BraudeTimetabler.Services
{
    public class InMemoryCoursesDataService : ICoursesDataService
    {
        private readonly IReadOnlyList<Course> courses;
        private readonly IReadOnlyList<CourseViewModel> coursesModels;
        private readonly ImmutableDictionary<string, Course> coursesDictionary;
        private readonly ImmutableDictionary<string, CourseViewModel> coursesModelDictionary;

        public InMemoryCoursesDataService()
        {
            courses  = Algorithm.AllCoursesData.AsReadOnly();
            coursesDictionary = courses.ToImmutableDictionary(course => course.Id);

            coursesModels = courses.Select(c => new CourseViewModel(c.Id, c.Name)).ToList().AsReadOnly();
            coursesModelDictionary = coursesModels.ToImmutableDictionary(course => course.Id);
        }

        public IReadOnlyList<CourseViewModel> GetAllModels() => coursesModels;

        public IReadOnlyList<Course> GetAll() => courses;
        public CourseViewModel GetModel(string id)
        {
            return coursesModelDictionary[id];
        }

        public Course Get(string id)
        {
            return coursesDictionary[id];
        }
    }
}