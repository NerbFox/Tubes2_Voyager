DOTNET := dotnet
CSC := dotnet csc

SRCALGODRIVERBFS := ../../../src/class/BFS.cs
SRCDRIVER := driver.cs

ALGODLL := bin/ALgo.dll
OUTPUT := -out:$(ALGODLL)

build:
	@echo "Compiling ghazi handler.."
	@$(CSC) $(SRCDRIVER) $(SRCALGODRIVERBFS) $(OUTPUT)

run:
	@$(DOTNET) $(ALGODLL)