DOTNET := dotnet
CSC := dotnet csc

SRCALGODRIVERDFS := ../../../src/class/DFS.cs
SRCALGODRIVERBFS := ../../../src/class/BFS.cs
SRCAL := ../../../src/class/Algorithm.cs
SRCDRIVER := driver.cs

ALGODLL := bin/ALgo.dll
OUTPUT := -out:$(ALGODLL)

build:
	@echo "Compiling inputHandler.."
	@$(CSC) $(SRCALGODRIVERDFS) $(SRCDRIVER) $(SRCALGODRIVERBFS) $(SRCAL) $(OUTPUT)

run:
	@$(DOTNET) $(ALGODLL)