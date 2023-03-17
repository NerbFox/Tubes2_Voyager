DOTNET := dotnet
CSC := dotnet csc

SRCALGODRIVERDFS := ../../../src/class/DFS.cs
SRCMAP := ../../../src/class/map.cs
SRCIN := ../../../src/class/inputHandler.cs
SRCAL := ../../../src/class/Algorithm.cs
SRCDRIVER := driver.cs

ALGODLL := bin/ALgo.dll
OUTPUT := -out:$(ALGODLL)

build:
	@echo "Compiling .."
	@$(CSC) $(SRCDRIVER) $(SRCALGODRIVERDFS) $(SRCMAP)  $(SRCIN)  $(SRCAL) $(OUTPUT)

run:
	@$(DOTNET) $(ALGODLL)