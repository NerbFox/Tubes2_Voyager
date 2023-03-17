DOTNET := dotnet
CSC := dotnet csc

SRCALGODRIVERDFS := ../../../src/class/DFS.cs
SRCALGODRIVERBFS := ../../../src/class/BFS.cs
SRCDRIVER := driver.cs

ALGODLL := bin/ALgo.dll
OUTPUT := -out:$(ALGODLL)

build:
	@echo "Compiling inputHandler.."
	@$(CSC) $(SRCALGODRIVERDFS) $(SRCDRIVER) $(SRCALGODRIVERBFS)  $(OUTPUT)

run:
	@$(DOTNET) $(ALGODLL)