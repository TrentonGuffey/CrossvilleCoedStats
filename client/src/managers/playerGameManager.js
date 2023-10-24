export const addPlayerGame = async (playerId, gameData) => {
    try {
        const response = await fetch(`/api/playergames`, {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify({ playerId, ...gameData }),
        });

        if (!response.ok) {
            throw new Error("Error adding player game stats");
        }

        return response.json(); // Optionally, you can return data from the response if needed.
    } catch (error) {
        console.error("Error adding player game stats: " + error);
        throw error; // Rethrow the error for handling in your component.
    }
};

export const deletePlayerGame = async (gameId) => {
    try {
        const response = await fetch(`/api/playergames/${gameId}`, {
            method: "DELETE",
        });

        if (!response.ok) {
            throw new Error("Error deleting player game");
        }

        // If you don't need any specific response data, you can simply return success.
        return "Player game deleted successfully";
    } catch (error) {
        console.error("Error deleting player game: " + error);
        throw error;
    }
};
