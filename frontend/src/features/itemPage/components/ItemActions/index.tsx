import { useState } from "react";
import ConfirmDialog from "../../../../shared/components/ConfirmDialog";

const ItemActions = () => {
    const [showDialog, setShowDialog] = useState<boolean>(false);

    return (
        <>
            <div className="flex flex-row gap-6">
                <button className="">U</button>
                <button onClick={() => setShowDialog(true)}>D</button>
            </div>     
            {showDialog && 
                <ConfirmDialog message="Are you sure you want to delete this item?" onConfirm={() => {setShowDialog(false)}} onCancel={() => setShowDialog(false)}/>
            } 
        </>
    );
};

export default ItemActions;