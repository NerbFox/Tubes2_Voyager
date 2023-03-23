DOTNET := dotnet
CSC := dotnet csc

SRCMAP := ../../../src/class/Map.cs
SRCINPUTHANDLER := ../../../src/class/InputHandler.cs
SRCALGO := ../../../src/class/Algo.cs
SRCDRIVER := Driver.cs

ALGODLL := bin/Algo.dll
OUTPUT := -out:$(ALGODLL)

all:
	@make -s clean
	@make -s runbuild

build:
	@echo "Compiling Algo.."
	@if not exist bin mkdir bin
	@$(CSC) $(SRCMAP) $(SRCINPUTHANDLER) $(SRCALGO) $(SRCDRIVER) $(OUTPUT)

run:
	@$(DOTNET) $(ALGODLL)

runbuild:
	@make -s build
	@make -s run

clean:
	@echo "Cleaning up Algo.."
	@if exist bin del /Q bin\ && rmdir bin