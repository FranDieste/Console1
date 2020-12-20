using Domain.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Domain.Aggregates.BookAggregate.Entities
{
   [Table("Books")]
    public class Book:IAgregate,IEntity
    {
        public Guid Id { get; set; }
        
        public string Title { get; set; }

        public string Isbn { get; set; }

        public int Pages { get; set; }
        public int Version { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
        public string UserCode { get; set; }

        private List<Chapter> _chapters { get; set; } = new List<Chapter>();

        public IEnumerable<Chapter> GetChapters()
        {
            return _chapters;
        }

        public void AddChapter(Chapter chapter)
        {
            if (chapter != null)
            {
              
                var currentChapter = _chapters.FirstOrDefault(x => x.Id == chapter.Id);
                if (currentChapter == null)
                {
                    _chapters.Add(chapter);
                }
                
               
            }
        }

        public void ModChapter(Chapter chapter)
        {
            if (chapter != null)
            {
                var currentChapter = _chapters.FirstOrDefault(x => x.Id == chapter.Id);
                if (currentChapter != null)
                {
                    currentChapter.Title = currentChapter.Title + " Modification " + DateTime.Now.ToString();
                }
            }
        }

        public void DelChapter(Chapter chapter)
        {
            if (chapter != null)
            {
                var currentChapter = _chapters.FirstOrDefault(x => x.Id == chapter.Id);
                if (currentChapter != null)
                {
                    _chapters.Remove(currentChapter);
                }
            }
        }


    }
}
