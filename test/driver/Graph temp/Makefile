DOTNET := dotnet
CSC := dotnet csc

SRCDFS := ../../../src/class/DFS.cs
SRCMAP := ../../../src/class/Map.cs
SRCINPUTHANDLER := ../../../src/class/InputHandler.cs
SRCALGO := ../../../src/class/Algorithm.cs
SRCGRAPH := ../../../src/class/Graph.cs
SRCDRIVER := Driver.cs

GRAPHDLL := bin/Graph.dll
OUTPUT := -out:$(GRAPHDLL)

all:
	@make -s clean
	@make -s runbuild

build:
	@echo "Compiling Graph.."
	@if not exist bin mkdir bin
	@$(CSC) $(SRCDFS) $(SRCMAP) $(SRCINPUTHANDLER) $(SRCALGO) $(SRCDRIVER) $(SRCGRAPH) $(OUTPUT)

run:
	@$(DOTNET) $(GRAPHDLL)

runbuild:
	@make -s build
	@make -s run

clean:
	@echo "Cleaning up Graph.."
	@if exist bin del /Q bin\ && rmdir bin