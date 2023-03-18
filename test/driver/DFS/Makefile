DOTNET := dotnet
CSC := dotnet csc

SRCDFS := ../../../src/class/DFS.cs
SRCMAP := ../../../src/class/Map.cs
SRCINPUTHANDLER := ../../../src/class/InputHandler.cs
SRCALGO := ../../../src/class/Algorithm.cs
SRCDRIVER := Driver.cs

DFSDLL := bin/DFS.dll
OUTPUT := -out:$(DFSDLL)

build:
	@echo "Compiling DFS.."
	@if not exist bin mkdir bin
	@$(CSC) $(SRCDFS) $(SRCMAP) $(SRCINPUTHANDLER) $(SRCALGO) $(SRCDRIVER) $(OUTPUT)

run:
	@$(DOTNET) $(DFSDLL)

runbuild:
	@make -s build
	@make -s run

clean:
	@echo "Cleaning up DFS.."
	@if exist bin del /Q bin\ && rmdir bin