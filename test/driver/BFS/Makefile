DOTNET := dotnet
CSC := dotnet csc

SRCALGODRIVERBFS := ../../../src/class/BFS.cs
SRCAL := ../../../src/class/Algorithm.cs
SRCDRIVER := driver.cs

ALGODLL := bin/ALgo.dll
OUTPUT := -out:$(ALGODLL)

build:
	@echo "Compiling ghazi handler.."
	@$(CSC) $(SRCDRIVER) $(SRCALGODRIVERBFS) $(SRCAL) $(OUTPUT)

run:
	@$(DOTNET) $(ALGODLL)