using Sphere.Application.Commons.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sphere.Application.UseCases.ClothingItem.Commands.Delete {
    public class DeleteClothingItemCommand : IUseCase<DeleteClothingItemResponse> {
        public Guid Id { get; set; }

        public DeleteClothingItemCommand(Guid id) {
            Id = id;
        }
    }
}
