DOTNET := dotnet
CSC := dotnet csc

SRCINPUTHANDLER := ../../../src/class/inputHandler.cs
SRCDRIVER := driver.cs

INPUTHANDLERDLL := bin/inputHandler.dll
OUTPUT := -out:$(INPUTHANDLERDLL)

build:
	@echo "Compiling inputHandler.."
	@if not exist bin mkdir bin
	@$(CSC) $(SRCINPUTHANDLER) $(SRCDRIVER) $(OUTPUT)

run:
	@$(DOTNET) $(INPUTHANDLERDLL)

runbuild:
	@make -s build
	@make -s run

clean:
	@echo "Cleaning up inputHandler.."
	@if exist bin del /Q bin\ && rmdir bin