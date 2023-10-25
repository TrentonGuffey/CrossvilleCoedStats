const apiUrl = "/api/players";

export const getPlayers = () => {
    return fetch(apiUrl).then((res) => res.json());
};

export const getPlayerById = (id) => {
    try {
        const response = fetch(`${apiUrl}/${id}`);
        if (!response.ok) {
            throw new Error("Error fetching data");
        }

        const data = response.json();
        return data;
    } catch (error) {
        console.error("Error fetching data: " + error);
    }};

export const addPlayer = async ( playerData  ) => {

    try {
        // console.log(playerData)
        const response = await fetch("/api/players", {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify(playerData),
        });
        console.log(response);
        if (!response.ok) {
            throw new Error("Error adding player on response");
        }
        console.log("Player added successfully");
        return response

    } catch (error) {
        console.error("Error adding player: " + error);
        // console.log(playerData);
    }

    
};
