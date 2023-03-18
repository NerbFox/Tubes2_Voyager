DOTNET := dotnet
CSC := dotnet csc

SRCINPUTHANDLER := ../../../src/class/InputHandler.cs
SRCMAP := ../../../src/class/Map.cs
SRCDRIVER := Driver.cs

INPUTMAPDLL := bin/Map.dll
OUTPUT := -out:$(INPUTMAPDLL)

build:
	@echo "Compiling Map.."
	@if not exist bin mkdir bin
	@$(CSC) $(SRCINPUTHANDLER) $(SRCMAP) $(SRCDRIVER) $(OUTPUT)

run:
	@$(DOTNET) $(INPUTMAPDLL)

runbuild:
	@make -s build
	@make -s run

clean:
	@echo "Cleaning up Map.."
	@if exist bin del /Q bin\ && rmdir bin