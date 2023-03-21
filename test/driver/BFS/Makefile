DOTNET := dotnet
CSC := dotnet csc

SRCMAP := ../../../src/class/Map.cs
SRCINPUTHANDLER := ../../../src/class/InputHandler.cs
SRCALGO := ../../../src/class/Algo.cs
SRCBFS := ../../../src/class/BFS.cs
SRCDRIVER := Driver.cs

BFSDLL := bin/BFS.dll
OUTPUT := -out:$(BFSDLL)

all:
	@make -s clean
	@make -s runbuild

build:
	@echo "Compiling BFS.."
	@if not exist bin mkdir bin
	@$(CSC) $(SRCMAP) $(SRCINPUTHANDLER) $(SRCALGO) $(SRCBFS) $(SRCDRIVER) $(OUTPUT)

run:
	@$(DOTNET) $(BFSDLL)

runbuild:
	@make -s build
	@make -s run

clean:
	@echo "Cleaning up BFS.."
	@if exist bin del /Q bin\ && rmdir bin