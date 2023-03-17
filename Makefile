build:
	@cd ./src && dotnet build --nologo && cd ..

run:
	@cd ./src && dotnet run && cd ..

clean:
	@cd ./src && dotnet clean --nologo && cd ..