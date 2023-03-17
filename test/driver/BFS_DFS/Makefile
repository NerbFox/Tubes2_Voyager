DOTNET := dotnet
CSC := dotnet csc

SRCDFS := ../../../src/class/DFS.cs
SRCBFS := ../../../src/class/BFS.cs
SRCALGO := ../../../src/class/algorithm.cs
SRCDRIVER := driver.cs

BFSDFSDLL := bin/BFSDFS.dll
OUTPUT := -out:$(BFSDFS)

build:
	@echo "Compiling BFS_DFS.."
	@if not exist bin mkdir bin
	@$(CSC) $(SRCDFS) $(SRCBFS) $(SRCALGO) $(SRCDRIVER) $(OUTPUT)

run:
	@$(DOTNET) $(BFSDFSDLL)

runbuild:
	@make -s build
	@make -s run

clean:
	@echo "Cleaning up BFS_DFS.."
	@if exist bin del /Q bin\ && rmdir bin