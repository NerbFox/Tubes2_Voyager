DOTNET := dotnet
CSC := dotnet csc

SRCINPUTHANDLER := ../../../src/class/inputHandler.cs
SRCDRIVER := driver.cs

INPUTHANDLERDLL := bin/inputHandler.dll
OUTPUT := -out:$(INPUTHANDLERDLL)

build:
	@echo "Compiling inputHandler.."
	@$(CSC) $(SRCINPUTHANDLER) $(SRCDRIVER) $(OUTPUT)

run:
	@$(DOTNET) $(INPUTHANDLERDLL)

clean:
	@echo "Cleaning up.."
	@del /Q bin\