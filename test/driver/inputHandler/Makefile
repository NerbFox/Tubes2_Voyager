DOTNET := dotnet
CSC := dotnet csc

SRCINPUTHANDLER := ../../../src/class/InputHandler.cs
SRCDRIVER := Driver.cs

INPUTHANDLERDLL := bin/InputHandler.dll
OUTPUT := -out:$(INPUTHANDLERDLL)

all:
	@make -s clean
	@make -s runbuild

build:
	@echo "Compiling InputHandler.."
	@if not exist bin mkdir bin
	@$(CSC) $(SRCINPUTHANDLER) $(SRCDRIVER) $(OUTPUT)

run:
	@$(DOTNET) $(INPUTHANDLERDLL)

runbuild:
	@make -s build
	@make -s run

clean:
	@echo "Cleaning up InputHandler.."
	@if exist bin del /Q bin\ && rmdir bin