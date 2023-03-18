all:
	@make -s clean
	@make -s build
	@make -s run

build:
	@cd ./src && dotnet build --nologo

run:
	@echo "Running the application..."
	@cd ./src && dotnet run

clean:
	@cd ./src && dotnet clean --nologo