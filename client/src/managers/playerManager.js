const apiUrl = "/api/players";

export const getPlayers = () => {
    return fetch(apiUrl).then((res) => res.json());
};

// export const getPlayerById = (id) => {
//     return fetch(`${apiUrl}/${id}`).then((res) => res.json());
// };
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