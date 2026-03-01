using Sphere.Application.Commons.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sphere.Application.UseCases.ClothingItems.Commands.Get {
    public class GetClothingItemQuery : IUseCase<GetClothingItemResponse> {
        public Guid Id { get; set; }

        public GetClothingItemQuery(Guid id) {
            Id = id;
        }
    }
}
