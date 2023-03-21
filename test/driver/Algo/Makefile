DOTNET := dotnet
CSC := dotnet csc

SRCDFS := ../../../src/class/DFS.cs
SRCMAP := ../../../src/class/Map.cs
SRCINPUTHANDLER := ../../../src/class/InputHandler.cs
SRCALGO := ../../../src/class/Algorithm.cs
SRCGRAPH := ../../../src/class/Algo.cs
SRCBFS := ../../../src/class/BFS.cs
SRCDRIVER := Driver.cs

GRAPHDLL := bin/Algo.dll
OUTPUT := -out:$(GRAPHDLL)

all:
	@make -s clean
	@make -s runbuild

build:
	@echo "Compiling Algo.."
	@if not exist bin mkdir bin
	@$(CSC) $(SRCDFS) $(SRCMAP) $(SRCINPUTHANDLER) $(SRCALGO) $(SRCBFS) $(SRCDRIVER) $(SRCGRAPH) $(OUTPUT)

run:
	@$(DOTNET) $(GRAPHDLL)

runbuild:
	@make -s build
	@make -s run

clean:
	@echo "Cleaning up Algo.."
	@if exist bin del /Q bin\ && rmdir bin