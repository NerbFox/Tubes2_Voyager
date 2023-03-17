DOTNET := dotnet
CSC := dotnet csc

SRCDFS := ../../../src/class/DFS.cs
SRCMAP := ../../../src/class/map.cs
SRCINPUTHANDLER := ../../../src/class/inputHandler.cs
SRCALGO := ../../../src/class/algorithm.cs
SRCDRIVER := driver.cs

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