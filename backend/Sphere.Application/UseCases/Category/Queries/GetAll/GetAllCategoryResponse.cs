using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sphere.Application.UseCases.Category.Queries.GetAll {
    public class GetAllCategoryResponse {
        public List<string> Categories { get; set; }

        public GetAllCategoryResponse(List<string> categories) {
            Categories = categories;
        }
    }
}
