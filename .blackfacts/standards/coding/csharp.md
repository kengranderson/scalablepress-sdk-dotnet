# C# Coding Standard — V1 Draft

Follow `engineering-principles.md` and `coding/common.md` first.

- Use nullable reference types for modern projects unless an existing project intentionally cannot.
- Use dependency injection at meaningful service/infrastructure boundaries.
- Define interfaces where they express real contracts, enable substitution/testing, or isolate architectural boundaries; do not create `IFoo` for every `Foo` mechanically.
- Prefer async all the way for genuinely asynchronous I/O; avoid blocking on tasks.
- Accept/propagate `CancellationToken` for cancellable server/background operations where appropriate.
- Prefer immutable models/records for value-like data where appropriate.
- Keep controllers/endpoints thin; business rules belong in appropriate domain/application services.
- Use typed/options-based configuration rather than scattered environment/config lookups.
- Use structured logging placeholders rather than string interpolation for structured values when supported.
- Use standard .NET/NuGet capabilities before adding dependencies.
- Test behavior and contracts rather than implementation details.
