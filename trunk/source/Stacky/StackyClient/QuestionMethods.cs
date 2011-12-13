using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stacky
{
    public partial class StackyClient
    {
        public IPagedList<Question> GetQuestions(QuestionSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            return Execute<Question>("questions", null,
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }

        public Question GetQuestion(int id, QuestionSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            return GetQuestions(id.ToArray(), sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter).FirstOrDefault();
        }

        public IPagedList<Question> GetQuestions(IEnumerable<int> ids, QuestionSort? sortBy = null, SortDirection? sortDirection = null, int? page = null, int? pageSize = null, DateTime? fromDate = null, DateTime? toDate = null, DateTime? min = null, DateTime? max = null, string filter = null)
        {
            return Execute<Question>("questions", new string[] { ids.Vectorize() },
                sortBy, sortDirection, page, pageSize, fromDate, toDate, min, max, filter);
        }
    }
}