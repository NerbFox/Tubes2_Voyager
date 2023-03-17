DOTNET := dotnet
CSC := dotnet csc

SRCALGODRIVERDFS := ../../../src/class/DFS.cs
SRCDRIVER := driver.cs

ALGODLL := bin/ALgo.dll
OUTPUT := -out:$(ALGODLL)

build:
	@echo "Compiling inputHandler.."
	@$(CSC) $(SRCDRIVER) $(SRCALGODRIVERDFS)  $(OUTPUT)

run:
	@$(DOTNET) $(ALGODLL)