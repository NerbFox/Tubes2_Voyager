DOTNET := dotnet
CSC := dotnet csc

SRCBFS := ../../../src/class/BFS.cs
SRCALGO := ../../../src/class/Algorithm.cs
SRCDRIVER := driver.cs

BFSDLL := bin/BFS.dll
OUTPUT := -out:$(BFSDLL)

build:
	@echo "Compiling BFS.."
	@if not exist bin mkdir bin
	@$(CSC) $(SRCBFS) $(SRCALGO) $(SRCDRIVER) $(OUTPUT)

run:
	@$(DOTNET) $(BFSDLL)

runbuild:
	@make -s build
	@make -s run

clean:
	@echo "Cleaning up BFS.."
	@if exist bin del /Q bin\ && rmdir bin