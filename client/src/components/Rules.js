import React from 'react';
import DocViewer, { DocViewerRenderers} from "@cyntler/react-doc-viewer";

export default function Rules () {
    const docs = [
      { uri: "https://www.crossvillesoftball.com/_files/ugd/e04ace_ce673e0bd8db4c509b3adbb7a3bb7a3b.pdf" }, // Remote file
    ];

    return (
    <div>
        <DocViewer style={{width: 500, height: 500}} pluginRenderers={DocViewerRenderers} documents={docs}  />
    </div>
    );
}
    