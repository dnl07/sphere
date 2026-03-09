# sphere

Sphere is a modular platform for managing, searching, and processing clothing items and images. It is designed for extensibility, currently under active development. Sphere provides a REST API for CRUD operations on clothing items and categories, with a frontend planned using React + TypeScript.

## Features

- **Clothing CRUD** - Create, read, update, and delete clothing items and categories, including image uploads.
- Image Processing - Background removal and segmentation for clothing images via a dedicated microservice.

## Architecture

Sphere follows Clean Architecture, structured into layers:

- Sphere.Api - REST API and entry point for external clients.

- Sphere.Application - Business logic, use cases, and service orchestration.

- Sphere.Domain - Core entities, aggregates, and domain rules.

- Sphere.Infrastructure - Data access, external service integration, and persistence.


## Installation

Clone with ```git clone --recurse-submodules https://github.com/dnl07/sphere.git```

## Future Plans

React + TypeScript frontend for managing and browsing clothing items.