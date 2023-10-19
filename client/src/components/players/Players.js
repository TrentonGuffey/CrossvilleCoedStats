import { useState } from "react";
import PlayerTable from "./PlayerTable";

export default function Players() {
    const [setDetailsPlayerId] = useState(null);

    return (
        <div className="container">
            <div className="row">
                <div className="col-sm-6">
                    <PlayerTable setDetailsPlayerId={setDetailsPlayerId} />
                </div>
            </div>
        </div>
    );
}

