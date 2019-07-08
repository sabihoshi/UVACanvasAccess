using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UVACanvasAccess.Model.Gradebook;
using UVACanvasAccess.Structures.Gradebook;
using UVACanvasAccess.Util;

namespace UVACanvasAccess.ApiParts {
    public partial class Api {

        [PaginatedResponse]
        private Task<HttpResponseMessage> RawGetGradebookDays(string courseId) {
            var url = $"courses/{courseId}/gradebook_history/days";
            return _client.GetAsync(url);
        }

        public async Task<IEnumerable<Day>> GetGradebookDays(ulong courseId) {
            var response = await RawGetGradebookDays(courseId.ToString());

            var models = await AccumulateDeserializePages<DayModel>(response);
            return from m in models
                   select new Day(this, m);
        }

        [PaginatedResponse]
        private Task<HttpResponseMessage> RawGetDailyGraders(string courseId, DateTime date) {
            var url = $"courses/{courseId}/gradebook_history/{date.ToIso8601Date()}";
            return _client.GetAsync(url);
        }

        public async Task<IEnumerable<Grader>> GetDailyGraders(ulong courseId, DateTime date) {
            var response = await RawGetDailyGraders(courseId.ToString(), date);

            var models = await AccumulateDeserializePages<GraderModel>(response);
            return from m in models
                   select new Grader(this, m);
        }
    }
}