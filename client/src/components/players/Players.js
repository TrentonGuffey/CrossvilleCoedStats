import { useState } from "react";
import PlayerTable from "./PlayerTable";


export default function Players() {
    const [setDetailsPlayerId] = useState(null);


    return (
        <div className="container">
            <div className="row">
                <PlayerTable setDetailsPlayerId={setDetailsPlayerId} />
            </div>
        </div>
    );
}

